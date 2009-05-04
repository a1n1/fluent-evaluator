﻿using FluentEvaluator.Actions;
using FluentEvaluator.Evaluations;

namespace FluentEvaluator.Conjunctions
{
	public class OtherwiseWhen : IOtherwiseWhen
	{
		public OtherwiseWhen(bool evaluationToPerform, EvaluationConclusion evaluationConclusion, bool continueEvaluations)
		{
			ContinueEvaluations = continueEvaluations;

			if(evaluationToPerform)
			{
				evaluationConclusion.Evaluate(true);
				ContinueEvaluations = false;
			}

			EvaluationToPerform = evaluationToPerform;

		}


		protected bool EvaluationToPerform
		{
			get;
			set;
		}

		public virtual IEvaluationAction When(bool boolToEvaluate)
		{
			EvaluationToPerform = boolToEvaluate;

			return new EvaluationAction(boolToEvaluate, EvaluationToPerform, ContinueEvaluations);
		}

        public NumericEvaluation<int> When(int numberToEvaluate)
		{
			return new NumericEvaluation<int>(numberToEvaluate, ContinueEvaluations);
		}

        public NumericEvaluation<double> When(double numberToEvaluate)
		{
			return new NumericEvaluation<double>(numberToEvaluate, ContinueEvaluations);
		}

        public NumericEvaluation<float> When(float numberToEvaluate)
		{
			return new NumericEvaluation<float>(numberToEvaluate, ContinueEvaluations);
		}

        public NumericEvaluation<long> When(long numberToEvaluate)
		{
			return new NumericEvaluation<long>(numberToEvaluate, ContinueEvaluations);
		}

        public NumericEvaluation<short> When(short numberToEvaluate)
		{
			return new NumericEvaluation<short>(numberToEvaluate, ContinueEvaluations);
		}

        public NumericEvaluation<decimal> When(decimal numberToEvaluate)
		{
			return new NumericEvaluation<decimal>(numberToEvaluate, ContinueEvaluations);
		}

        public NumericEvaluation<uint> When(uint numberToEvaluate)
		{
			return new NumericEvaluation<uint>(numberToEvaluate, ContinueEvaluations);
		}

        public NumericEvaluation<ulong> When(ulong numberToEvaluate)
		{
			return new NumericEvaluation<ulong>(numberToEvaluate, ContinueEvaluations);
		}

        public NumericEvaluation<ushort> When(ushort numberToEvaluate)
		{
			return new NumericEvaluation<ushort>(numberToEvaluate, ContinueEvaluations);
		}

		protected bool ContinueEvaluations
		{
			get; set;
		}

        public virtual ObjectEvaluation<TypeToEvaluate> When<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new ObjectEvaluation<TypeToEvaluate>(objectToEvaluate, ContinueEvaluations);
		}
	}

	public interface IOtherwiseWhen:IWhen
	{
	}
}