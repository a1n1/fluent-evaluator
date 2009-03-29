﻿using FluentEvaluator.Actions;
using FluentEvaluator.Evaluations;

namespace FluentEvaluator.Conjunctions
{
	public class OrWhen : IOrWhen
	{
		public OrWhen(bool evaluationToPerform, bool continueEvaluations)
		{
			EvaluationToPerform = evaluationToPerform;
			ContinueEvaluations = continueEvaluations;
		}

		protected bool EvaluationToPerform
		{
			get; set;
		}

		protected bool ContinueEvaluations
		{
			get;
			set;
		}

		public virtual IEvaluationAction This(bool boolToEvaluate)
		{
			EvaluationToPerform |= boolToEvaluate;

			return new EvaluationAction(boolToEvaluate, EvaluationToPerform, ContinueEvaluations);
		}

		public virtual OrEvaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new OrEvaluation<TypeToEvaluate>(objectToEvaluate, EvaluationToPerform, ContinueEvaluations);
		}
	}
}