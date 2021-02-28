using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interception;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _type;
        public ValidationAspect(Type type)
        {
            //Defensive
            if (!typeof(IValidator).IsAssignableFrom(type))
            {
                throw new System.Exception("Bu bir validator türü değil");
            }
            _type = type;
        }
        public override void OnBefore(IInvocation invocation)
        {
            var validator =(IValidator)Activator.CreateInstance(_type);//type nı verdiğin validatoru new liyo
            var entityType = _type.BaseType.GetGenericArguments()[0];//generik yapının 1. nesnesine ulaştım
            var entities = invocation.Arguments.Where(p => p.GetType() == entityType);
            foreach (var item in entities)
            {
                ValidationTool.Validate(item, validator);
            }

        }
    }
}
