using FluentEvaluator.Evaluations;

namespace FluentEvaluator.Conjunctions
{
	public interface IOrWhen : IWhen
	{
		OrEvaluation<TypeToEvaluate> When<TypeToEvaluate>(TypeToEvaluate objectToEvaluate);
	}
}