using FluentEvaluator.Actions;
using FluentEvaluator.Evaluations;

namespace FluentEvaluator
{
	public class When
	{
		public static ObjectEvaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new ObjectEvaluation<TypeToEvaluate>(objectToEvaluate, true);
		}

		public static EvaluationAction This(bool boolToEvaluate)
		{
			return new EvaluationAction(boolToEvaluate, boolToEvaluate, true);
		}

		public static NumericEvaluation<int> This(int integerToEvaluate)
		{
			return new NumericEvaluation<int>(integerToEvaluate, true);
		}
	}
}