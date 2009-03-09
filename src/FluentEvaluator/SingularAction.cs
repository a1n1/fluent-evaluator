﻿using System;
using System.Reflection;

namespace FluentEvaluator
{
	public class SingularAction<TypeToEvaluate> : EvaluationAction
	{
		public SingularAction(object objectToEvaluate, bool evaluationToPerform) : base(objectToEvaluate, evaluationToPerform)
		{
		}

		public TypeToEvaluate CreateIt(params object[] arguments)
		{
			ActionToPerformAfterEvaluation = () =>
			{
				try
				{
					ConstructorInfo currentCtorInfo = typeof(TypeToEvaluate).GetConstructor(GetConstructorTypes(arguments));
					ObjectToEvaluate = currentCtorInfo == null ? default(TypeToEvaluate) : currentCtorInfo.Invoke(arguments);
				}
				catch (Exception ex)
				{
					throw new ApplicationException("could not invoke costructor", ex);
				}
			};
			PerformAction();
			return (TypeToEvaluate)ObjectToEvaluate;
		}
	}
}