using System;
using FluentEvaluator.Actions;
using FluentEvaluator.Evaluations;

namespace FluentEvaluator
{
	public class When
	{
		public static IEvaluation This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			if (objectToEvaluate is IComparable)
				return new ComparableEvaluation<TypeToEvaluate>(objectToEvaluate, true);
			
			return new ObjectEvaluation<TypeToEvaluate>(objectToEvaluate, true);
		}

		public static EvaluationAction This(bool boolToEvaluate)
		{
			return new EvaluationAction(boolToEvaluate, boolToEvaluate, true);
		}
	}
}