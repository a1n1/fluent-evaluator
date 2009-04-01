using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public interface IComparableEvaluation<TypeOfAction, TypeToEvaluate> : IEvaluation//<TypeOfAction, TypeToEvaluate>
		where TypeOfAction : EvaluationAction
	{
		TypeOfAction IsGreaterThan(TypeToEvaluate numericValue);
		
		TypeOfAction IsGreaterThanOrEqualTo(TypeToEvaluate numericValue);

		TypeOfAction IsLessThan(TypeToEvaluate numericValue);

		TypeOfAction IsLessThanOrEqualTo(TypeToEvaluate numericValue);
	}
}