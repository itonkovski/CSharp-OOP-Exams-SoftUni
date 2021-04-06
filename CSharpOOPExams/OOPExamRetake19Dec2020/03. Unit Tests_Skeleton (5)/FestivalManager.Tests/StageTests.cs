// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
	public class StageTests
    {
		[Test]
		public void ValidateNullValueWorksCorrectly()
		{
			var performer = new Performer(null, null, 0);
			Assert.Throws<ArgumentNullException>(() => ValidateNullValueWorksCorrectly(Performer performer));
		}

		[Test]
	    public void AddPerformerMethodShouldThrowExceptionUnder18()
	    {
			Assert.Throws<ArgumentException>(() => new Performer("Ivan", "Ivanov", 16));
		}

	}
}