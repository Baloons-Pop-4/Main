namespace BalloonsPop.Common.Gadgets
{
    using System;

    public class Switch<T>
    {
        private bool hasMatched;

        public Switch(T switchArgument, bool fallThrough = false)
        {
            this.SwitchArgument = switchArgument;
            this.FallThrough = fallThrough;
            this.hasMatched = false;
        }

        public T SwitchArgument { get; private set; }
        
        public bool FallThrough { get; set; }

        // case with key comparison, allows traditional switch cases
        public Switch<T> Case(T key, Action function)
        {
            return this.Case(object.Equals(this.SwitchArgument, key), function);
        }

        // case with predicates, adds flexibility to the switch statement
        public Switch<T> Case(Func<T, bool> predicate, Action function)
        {
            return this.Case(predicate(this.SwitchArgument), function);
        }

        // case with bool conditions, adds flexibility to the switch statement
        public Switch<T> Case(bool condition, Action function)
        {
            if (condition && (this.FallThrough || !this.hasMatched))
            {
                function();
                this.hasMatched = true;
            }

            return this;
        }

        // default case, trivial switch command
        public void Default(Action function)
        {
            this.Case(x => true, function);
        }
    }
}
