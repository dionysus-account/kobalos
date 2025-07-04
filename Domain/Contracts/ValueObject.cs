namespace Kobalos.Domain.Contracts
{
    internal abstract class ValueObject : IEquatable<ValueObject>
    {
        public static bool operator ==(ValueObject? left, ValueObject? right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !(left == right);
        }

        public bool Equals(ValueObject? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override bool Equals(object? obj)
        {
            return obj is ValueObject && this.Equals(obj as ValueObject);
        }

        public override int GetHashCode()
        {
            return this.GetEqualityComponents()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => (x * 397) ^ y);
        }

        protected abstract IEnumerable<object> GetEqualityComponents();
    }
}
