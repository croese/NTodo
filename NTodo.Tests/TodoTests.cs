using NTodo.Core;

namespace NTodo.Tests;

public class TodoTests
{
    [TestCase("measure space for +chapelShelving @chapel", null, null, null,
        "measure space for +chapelShelving @chapel")]
    [TestCase("measure space for +chapelShelving @chapel", 'A', null, null,
        "(A) measure space for +chapelShelving @chapel")]
    [TestCase("measure space for +chapelShelving @chapel", 'A', "2016-04-30", null,
        "(A) 2016-04-30 measure space for +chapelShelving @chapel")]
    [TestCase("measure space for +chapelShelving @chapel", null, "2016-04-30", "2016-05-20",
        "x 2016-05-20 2016-04-30 measure space for +chapelShelving @chapel")]
    [TestCase("measure space for +chapelShelving @chapel", 'A', "2016-04-30", "2016-05-20",
        "x (A) 2016-05-20 2016-04-30 measure space for +chapelShelving @chapel")]
    public void ToStringReturnsFormattedLine(string desc, char? priority, string? created, string? completed,
        string expected)
    {
        var t = new Todo(desc, priority, created == null ? null : DateTime.Parse(created),
            completed == null ? null : DateTime.Parse(completed));

        Assert.That(t.ToString(), Is.EqualTo(expected));
    }

    [Test]
    public void ProjectsCanBeExtractedFromATodo()
    {
        var t = new Todo("(A) Call Mom +Family +PeaceLoveAndHappiness @iphone @phone", 'A', null, null);

        Assert.That(t.Projects, Is.EquivalentTo(new[] { "+Family", "+PeaceLoveAndHappiness" }));
    }

    [Test]
    public void ContextsCanBeExtractedFromATodo()
    {
        var t = new Todo("(A) Call Mom +Family +PeaceLoveAndHappiness @iphone @phone", 'A', null, null);

        Assert.That(t.Contexts, Is.EquivalentTo(new[] { "@iphone", "@phone" }));
    }
}