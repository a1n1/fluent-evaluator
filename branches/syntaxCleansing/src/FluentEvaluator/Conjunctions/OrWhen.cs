using FluentEvaluator.Actions;
using FluentEvaluator.Evaluations;

namespace FluentEvaluator.Conjunctions
{
	public class OrWhen : IConjunctiveWhen
	{
		public OrWhen(bool evaluationToPerform, bool continueEvaluations, object objectToEvaluate)
		{
			EvaluationToPerform = evaluationToPerform;
			ContinueEvaluations = continueEvaluations;
			ObjectToEvaluate = objectToEvaluate;
		}

		protected object ObjectToEvaluate { get; set; }

		protected bool EvaluationToPerform
		{
			get; set;
		}

		protected bool ContinueEvaluations
		{
			get;
			set;
		}

		public IObjectEvaluation<EvaluationAction, object> It
		{
			get
			{
				return new AndEvaluation<object>(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
			}
		}

		public virtual IEvaluationAction This(bool boolToEvaluate)
		{
			EvaluationToPerform |= boolToEvaluate;

			return new EvaluationAction(boolToEvaluate, EvaluationToPerform, ContinueEvaluations);
		}

		public NumericEvaluation<int> This(int numberToEvaluate)
		{
			return new NumericEvaluation<int>(numberToEvaluate, ContinueEvaluations);
		}

		public NumericEvaluation<double> This(double numberToEvaluate)
		{
			return new NumericEvaluation<double>(numberToEvaluate, ContinueEvaluations);
		}

		public NumericEvaluation<float> This(float numberToEvaluate)
		{
			return new NumericEvaluation<float>(numberToEvaluate, ContinueEvaluations);
		}

		public NumericEvaluation<long> This(long numberToEvaluate)
		{
			return new NumericEvaluation<long>(numberToEvaluate, ContinueEvaluations);
		}

		public NumericEvaluation<short> This(short numberToEvaluate)
		{
			return new NumericEvaluation<short>(numberToEvaluate, ContinueEvaluations);
		}

		public NumericEvaluation<decimal> This(decimal numberToEvaluate)
		{
			return new NumericEvaluation<decimal>(numberToEvaluate, ContinueEvaluations);
		}

		public NumericEvaluation<uint> This(uint numberToEvaluate)
		{
			return new NumericEvaluation<uint>(numberToEvaluate, ContinueEvaluations);
		}

		public NumericEvaluation<ulong> This(ulong numberToEvaluate)
		{
			return new NumericEvaluation<ulong>(numberToEvaluate, ContinueEvaluations);
		}

		public NumericEvaluation<ushort> This(ushort numberToEvaluate)
		{
			return new NumericEvaluation<ushort>(numberToEvaluate, ContinueEvaluations);
		}

		public virtual IObjectEvaluation<EvaluationAction, TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new OrEvaluation<TypeToEvaluate>(objectToEvaluate, EvaluationToPerform, ContinueEvaluations);
		}
	}
}