
using Microsoft.AspNetCore.Mvc;
using PlatTraining.Controllers;
using System.Reflection;

var type = typeof(ControllerBase);

var excludedTypes = new Type[]
{
                typeof(TenantControllerBase),
                typeof(AuthenticationController)
};

var assembly = Assembly.GetAssembly(typeof(TenantControllerBase));
var types = assembly.GetTypes()
    .Where(t => !excludedTypes.Contains(t) && t.BaseType == type);


Console.ReadLine();


public class TotalBase { }
public class MyBase : TotalBase { }
public class My : MyBase { }
public class Your : TotalBase { }