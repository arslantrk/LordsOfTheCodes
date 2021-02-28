using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interception
{
    public class InterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            //var methodAttributes = type.GetMethod(method.Name)
            //    .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            //classAttributes.AddRange(methodAttributes);
            //return classAttributes.OrderBy(x => x.Priority).ToArray();
            var allAttributes = new List<MethodInterceptionBaseAttribute>();
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            allAttributes.AddRange(classAttributes);
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            allAttributes.AddRange(methodAttributes);
            return allAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
