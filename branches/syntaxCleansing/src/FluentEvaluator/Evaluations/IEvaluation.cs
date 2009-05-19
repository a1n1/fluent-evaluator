using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public interface IEvaluation<TypeOfAction, TypeToEvaluate> where TypeOfAction : IEvaluationAction
	{
		TypeOfAction Equals(TypeToEvaluate objectToEqual);
	}
}