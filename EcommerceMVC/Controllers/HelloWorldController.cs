using Microsoft.AspNetCore.Mvc;

namespace TestingMVC.Controllers
{
    public class HelloWorldController : Controller
    { 

        //in program.cs , given defalut mapcontrollerroute with name , contoller => home, action => index and parameter {id} 
        //index is default action of HelloWorldController  , so no need to route on browser url
        //https://localhost:7156/HelloWorld
        public string Index()
        {
            return "Welcome index mvc hello world";

        }
 

        //(without pattern url's id parameter)
        //with query string parameter            
        //https://localhost:7156/HelloWorld/Hello?name="Yu"
        public string HelloWithParameter(string name)
        {
            return $"Welcome par {name}";
        }
        //https://localhost:7156/HelloWorld/Hello?name="Yu"&times=3
        public string HelloWithParameters(string name, int times=1)
        {
            return $"Welcome {times} times par {name}";
        }

        //(contain pattern url's id parameter)
        //https://localhost:7156/HelloWorld/Hello/4?name="Yu"&times=3    /4 => /{id} in mapcontrollerroute
        //so, in this stage, we matched with default mapcontrollerroute in program.cs  
        public string HelloWithParametersId(string name, int Id, int times = 1)
        {
            return $"Welcome {times} times par {name}, your id is {Id}";
        }

        //with start view
        //create Views /HelloWorld/StartView.cshtml  , you can create Index.cshtml also
        //https://localhost:7156/HelloWorld/StartView
        //https://localhost:7156/HelloWorld/  => if index action method
        public IActionResult StartView()
        {
            return View();
        }

        //https://localhost:7156/HelloWorld/Hello
        public IActionResult Hello(string name, int numtimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numtimes;
            return View();
        }
    }
}
