using Microsoft.AspNetCore.Mvc;
using PlatTraining.Controllers;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace PlatTraining.Tests
{
    public class TypeTests
    {
        [Fact]
        public void DoNotInheritFromControllerBase()
        {
            var type = typeof(ControllerBase);

            var excludedTypes = new Type[]
            {
                typeof(TenantControllerBase),
                typeof(AuthenticationController)
            };

            var assembly = Assembly.GetAssembly(typeof(TenantControllerBase));
            var types = assembly.GetTypes()
                .Where(t => !excludedTypes.Contains(t) && t.BaseType == type)
                .Select(t => t.FullName)
                .ToList();

            if (types.Any())
            {
                throw new InvalidOperationException($"The following controllers are inherit from ControllerBase {string.Join(", ", types)}." +
                    $" Please use existing controllers");
            }
        }
    }
}