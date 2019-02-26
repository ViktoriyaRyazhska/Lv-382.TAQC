using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTasks.CodeExamples
{
    class Inheritance
    {
    }

    public interface HasFeature { }
    public interface ShouldDo
    {
        void Function();
    }
    public abstract class Person
    {
        public void SharedFeature() { }
        public abstract void PersonSpecificFeature();
    }
    public class SpecificPerson : Person, ShouldDo, HasFeature
    {
        public void Function() { }
        public override void PersonSpecificFeature() { }
    }
}
