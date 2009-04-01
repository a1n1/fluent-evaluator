using System;
using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public interface IEvaluation<TypeOfAction, TypeToEvaluate> where TypeOfAction : EvaluationAction
	{
		TypeOfAction EqualsThis(TypeToEvaluate objectToEqual);

		TypeOfAction IsNull
		{
			get;
		}

		TypeOfAction IsEmpty
		{
			get;
		}

		TypeOfAction IsNotEmpty
		{
			get;
		}

		TypeOfAction IsNotNull
		{
			get;
		}

		TypeOfAction Satisfies(Predicate<TypeToEvaluate> match);

		TypeOfAction IsGreaterThan(TypeToEvaluate numericValue);

		TypeOfAction IsGreaterThanOrEqualTo(TypeToEvaluate numericValue);

		TypeOfAction IsLessThan(TypeToEvaluate numericValue);

		TypeOfAction IsLessThanOrEqualTo(TypeToEvaluate numericValue);
	}
}