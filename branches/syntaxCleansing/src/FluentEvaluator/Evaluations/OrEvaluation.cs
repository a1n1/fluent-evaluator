using System;
using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public class OrEvaluation<TypeToEvaluate> : IObjectEvaluation<IEvaluationAction, TypeToEvaluate>
	{
		public OrEvaluation(TypeToEvaluate objectToEvaluate, bool conjuctiveEvaluation, bool continueEvaluations)
		{
			ObjectToEvaluate = objectToEvaluate;
			EvaluationToPerform = conjuctiveEvaluation;
			ContinueEvaluations = continueEvaluations;
		}
        
		protected virtual TypeToEvaluate ObjectToEvaluate
		{
			get;
			set;
		}

		protected virtual bool EvaluationToPerform
		{
			get;
			set;
		}

		protected bool ContinueEvaluations
		{
			get;
			set;
		}

		public IEvaluationAction IsNull
		{
			get
			{
				EvaluationToPerform |= (Equals(ObjectToEvaluate, default(TypeToEvaluate)));
				return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
			}
		}

		public IEvaluationAction IsEmpty
		{
			get
			{
				EvaluationToPerform |= EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(ObjectToEvaluate);
				return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
			}
		}

		public IEvaluationAction IsNotEmpty
		{
			get
			{
				EvaluationToPerform |= EvaluationUtilities.CheckIfObjectToEvaluateIsNotEmpty(ObjectToEvaluate);
				return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
			}
		}

		public IEvaluationAction Equals(TypeToEvaluate objectToEqual)
		{
			if (Equals(ObjectToEvaluate, default(TypeToEvaluate)))
				EvaluationToPerform |= false;
			else
				EvaluationToPerform |= (ObjectToEvaluate.Equals(objectToEqual));

			return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
		}

		public IEvaluationAction IsNotNull
		{
			get
			{
				EvaluationToPerform |= (!Equals(ObjectToEvaluate, default(TypeToEvaluate)));
				return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
			}
		}

		public IEvaluationAction Satisfies(Predicate<TypeToEvaluate> match)
		{
			EvaluationUtilities.EnsurePredicateIsValid(match);

			EvaluationToPerform |= (match(ObjectToEvaluate));

			return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
		}
	}
}