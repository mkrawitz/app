﻿ using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(FrontController))]  
  public class FrontControllerSpecs
  {
    public abstract class concern : Observes<IProcessRequests,
                                      FrontController>
    {
        
    }

   
    public class when_processing_a_request  : concern
    {

      Establish c = () =>
      {
        command_that_Can_handle_request = fake.an<IProcessOneRequest>();
        command_registry = depends.on<IFindCommands>();
        request = new object();

        command_registry.setup(x => x.get_the_command_that_can_process(request))
          .Return(command_that_Can_handle_request);
      };

      Because b = () =>
        sut.handle(request);
        
      It should_delegate_the_processing_to_the_Command_that_can_handle_The_request = () =>
        command_that_Can_handle_request.received(x => x.process(request));

      static IProcessOneRequest command_that_Can_handle_request;
      static object request;
      static IFindCommands command_registry;
    }
  }
}
