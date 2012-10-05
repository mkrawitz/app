using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.web.core;
using app.bowling;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs.bowling
{
    public class PlayerSpec
    {

        public abstract class concern : Observes<Player>
        {
        }

        public class when_determining_player_score : concern
        {
            public class we_have_decided_that_each_player_keeps_track_of_their_own_score
            {
                public class at_the_beginning_of_the_game
                {
                    public class we_have_decided_that_player_self_initializes
                    {
                        private Establish c = () =>
                                                  {
                                                      throw_simulator = depends.on<IThrowBalls>();
                                                      throw_simulator.setup(x => x.pins_knocked_down()).Return(5);
                                                  };

                        private It should_equal_zero = () =>
                                                       sut.score().ShouldEqual(0);

                        public static
                            IThrowBalls throw_simulator;
                    }
                }

                public class after_throwing_one_ball
                {
                    private Establish c = () =>
                                              {
                                                  throw_simulator = depends.on<IThrowBalls>();
                                                  throw_simulator.setup(x => x.pins_knocked_down()).Return(5);
                                              };

                    private Because b = () =>
                                        sut.throw_ball();

                    private
                        It score_should_equal = () =>
                                                sut.score().ShouldEqual(score_from_one_ball);

                    public static
                        int score_from_one_ball = 5;

                    public static
                        IThrowBalls throw_simulator;
                }

                public class after_throwing_all_balls
                {
                    public class after_throwing_twenty_balls
                    {
                        private Establish c = () =>
                                                  {
                                                      throw_simulator = depends.on<IThrowBalls>();
                                                      throw_simulator.setup(x => x.pins_knocked_down()).Return(5);
                                                  };

                        private Because b = () =>
                                                {
                                                    for (int i = 0; i < 20; i++)
                                                        sut.throw_ball();
                                                };

                        private It score_should_equal = () =>
                                                        sut.score().ShouldEqual(20*score_from_one_ball);

                        public static
                            int score_from_one_ball = 5;

                        public static
                            IThrowBalls throw_simulator;
                    }
                }

                /*
                public class multiple_players_can_track_their_own_score
                {
                    public class multiple_players_each_throw_twenty_balls
                    {
                        private Establish c = () =>
                        {
                            throw_simulator_playerA = depends.on<IThrowBalls>();
                            throw_simulator_playerA.setup(x => x.pins_knocked_down()).Return(5);
                        };

                        private Because b = () =>
                        {
                            for (int i = 0; i < 20; i++)
                                sut.throw_ball();
                        };

                        private It score_should_equal = () =>
                                                        sut.score().ShouldEqual(20 * score_from_one_ball);

                        public static
                            int score_from_one_ball = 5;

                        public static
                            IThrowBalls throw_simulator;
                    }
                }
                 */
            }
        }
    }
}
