using FluentEvaluator.Actions;
using FluentEvaluator.Evaluations;

namespace FluentEvaluator.Conjunctions
{
	public interface IWhen
	{
		NumericEvaluation<int> When(int numberToEvaluate);

		NumericEvaluation<double> When(double numberToEvaluate);

        NumericEvaluation<float> When(float numberToEvaluate);

        NumericEvaluation<long> When(long numberToEvaluate);

        NumericEvaluation<short> When(short numberToEvaluate);

        NumericEvaluation<decimal> When(decimal numberToEvaluate);

        NumericEvaluation<uint> When(uint numberToEvaluate);

        NumericEvaluation<ulong> When(ulong numberToEvaluate);

        NumericEvaluation<ushort> When(ushort numberToEvaluate);
	}

	public interface ISingularWhen : IWhen
	{
        IEvaluation<SingularAction<TypeToEvaluate>, TypeToEvaluate> When<TypeToEvaluate>(TypeToEvaluate objectToEvaluate);
	}
}