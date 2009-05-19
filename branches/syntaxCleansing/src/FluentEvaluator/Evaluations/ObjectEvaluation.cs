using System;
using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public class ObjectEvaluation<TypeToEvaluate> : IObjectEvaluation<SingularAction<TypeToEvaluate>, TypeToEvaluate>
	{
		public ObjectEvaluation(TypeToEvaluate objectToEvaluate, bool continueEvaluations)
		{
			ObjectToEvaluate = objectToEvaluate;
			ContinueEvaluations = continueEvaluations;
		}

		protected bool ContinueEvaluations { get; set; }

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

		public SingularAction<TypeToEvaluate> IsNull
		{
			get
			{
				EvaluationToPerform = (Equals(ObjectToEvaluate, default(TypeToEvaluate)));
				return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
			}
		}

		public SingularAction<TypeToEvaluate> IsEmpty
		{
			get
			{
				EvaluationToPerform = EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(ObjectToEvaluate);
				return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
			}
		}

		public SingularAction<TypeToEvaluate> IsNotEmpty
		{
			get
			{
				EvaluationToPerform = EvaluationUtilities.CheckIfObjectToEvaluateIsNotEmpty(ObjectToEvaluate);
				return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
			}
		}

		public SingularAction<TypeToEvaluate> Equals(TypeToEvaluate objectToEqual)
		{
			EvaluationToPerform = (ObjectToEvaluate.Equals(objectToEqual));
			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
		}
        
		public SingularAction<TypeToEvaluate> IsNotNull
		{
			get
			{
				EvaluationToPerform = (!Equals(ObjectToEvaluate, default(TypeToEvaluate)));
				return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
			}
		}

		public SingularAction<TypeToEvaluate> Satisfies(Predicate<TypeToEvaluate> match)
		{
			EvaluationUtilities.EnsurePredicateIsValid(match);

			EvaluationToPerform = (match(ObjectToEvaluate));

			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
		}
	}
}