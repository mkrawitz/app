using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs.micro_machines
{
    [Subject(typeof(SurfaceSpec))]
    public class SurfaceSpec
    {
        public abstract class concern : Observes<SurfaceSpec>
        {

        }

        public class has_notion_of_boundaries : concern {

            public class can_determine_inclusion
            {
                public class position_is_on_surface
                {
                    private Establish c = () =>
                                              {
                                                  positionFactory = fake.an<IPositionFactory>();
                                                  position = positionFactory.createDefaultPosition();
                                                  sut.setup(x => x.includes(position)).Return(true);
                                              };

                    private Because b = () =>
                                        sut.ProcessRequest(a_context);

                    private It detects_when_position_is_included_ = () =>
                                                                    sut.includes(position).ShouldEqual(true);

                    private static IPositionFactory positionFactory;
                    private static IKnowMyPosition position;
                }

                public class position_is_not_on_surface
                {
                    private Establish c = () =>
                            {
                                positionFactory = fake.an<IPositionFactory>();
                                position = positionFactory.createInfinitePosition();
                                sut.setup(x => x.includes(position)).Return(false);
                            };

                    private Because b = () =>
                                        sut.ProcessRequest(a_context);

                    private It detects_when_position_is_not_included_ = () =>
                                                                    sut.includes(position).ShouldEqual(false);

                    private static IPositionFactory positionFactory;
                    private static IKnowMyPosition position;
                }
            }
        }
}
