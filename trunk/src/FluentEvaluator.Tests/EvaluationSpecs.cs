﻿using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class EvaluationSpecs : ContextSpecification
	{
		protected TestableFoo _testableFooOne;
		protected TestableFoo _testableFooTwo;
		protected int _count = 1;
	}

	[TestFixture]
	[Concern("EqualsThis evaluation")]
	public class when_objects_equal : EvaluationSpecs
	{
		protected override void Context()
		{
			_testableFooOne = new TestableFoo();
			_testableFooTwo = _testableFooOne;

			When.This(_testableFooOne).EqualsThis(_testableFooTwo).DoThis(() => _count++);
		}

		[Test]
		[Observation]
		public void count_should_equal_two()
		{
			_count.ShouldEqual(2);
		}
	}

	[TestFixture]
	[Concern("EqualsThis evaluation")]
	public class when_objects_dont_equal : EvaluationSpecs
	{
		protected override void Context()
		{
			_testableFooOne = new TestableFoo();
			_testableFooTwo = new TestableFoo();

			When.This(_testableFooOne).EqualsThis(_testableFooTwo).DoThis(() => _count++);
		}

		[Test]
		[Observation]
		public void count_should_equal_one()
		{
			_count.ShouldEqual(1);
		}
	}

	[TestFixture]
	[Concern("Is Not Null")]
	public class when_is_not_null : EvaluationSpecs
	{
		protected override void Context()
		{
			_testableFooOne = new TestableFoo();

			When.This(_testableFooOne).IsNotNull().DoThis(() => _count++);
		}

		[Test]
		[Observation]
		public void count_should_equal_two()
		{
			_count.ShouldEqual(2);
		}
	}

	[TestFixture]
	[Concern("Is Not Null")]
	public class when_is_null : EvaluationSpecs
	{
		protected override void Context()
		{
			_testableFooOne = null;

			When.This(_testableFooOne).IsNotNull().DoThis(() => _count++);
		}

		[Test]
		[Observation]
		public void count_should_equal_one()
		{
			_count.ShouldEqual(1);
		}
	}
}