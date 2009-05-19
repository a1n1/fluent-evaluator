using System;
using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public interface INumericEvaluation<TypeOfAction, TypeToEvaluate> : IEvaluation<TypeOfAction, TypeToEvaluate>
		where TypeOfAction : IEvaluationAction
		where TypeToEvaluate : IComparable<TypeToEvaluate>
	{
		TypeOfAction IsGreaterThan(TypeToEvaluate numericValue);
		
		TypeOfAction IsLessThan(TypeToEvaluate numericValue);
	}
}