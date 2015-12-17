using System;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ThinqCore
{
	public class ExpressionProxy
	{
		Expression<Func<int>> _expression;
		Type _type = typeof(int);

		public ExpressionProxy()
			: this(0)
		{
		}

		public ExpressionProxy(int startValue)
		{
			_expression = () => startValue;
		}

		internal ExpressionProxy(Expression expression)
		{
			_expression = (Expression<Func<int>>)expression;
		}

		public int Compile()
		{
			Func<int> func = _expression.Compile();
			return func.Invoke();
		}

		// Implicit conversion from int to ExpressionProxy.
		public static implicit operator ExpressionProxy(int number)
		{
			return new ExpressionProxy(number);
		}

		// Explicit conversion from ExpressionProxy to int. 
		public static explicit operator int(ExpressionProxy proxy)
		{
			return proxy.Compile();
		}

		public static ExpressionProxy operator +(ExpressionProxy lhs, ExpressionProxy rhs)
		{
			return new ExpressionProxy(Expression<Func<int>>.Add(lhs._expression, rhs._expression));
		}

		public static ExpressionProxy operator -(ExpressionProxy lhs, ExpressionProxy rhs)
		{
			return new ExpressionProxy(Expression<Func<int>>.Subtract(lhs._expression, rhs._expression));
		}
		
		public static ExpressionProxy operator !(ExpressionProxy proxy)
		{
			return new ExpressionProxy(Expression.Negate(proxy._expression));
		}

		public static bool operator ==(ExpressionProxy lhs, ExpressionProxy rhs)
		{
			if (System.Object.ReferenceEquals(lhs, rhs))
			{
				return true;
			}

			// If one is null, but not both, return false.
			if (((object)lhs == null) || ((object)rhs == null))
			{
				return false;
			}

			int l = lhs.Compile();
			int r = rhs.Compile();

			return l.Equals(r);
		}

		public static bool operator !=(ExpressionProxy lhs, ExpressionProxy rhs)
		{
			return !(lhs == rhs);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			else if (obj is int)
			{
				int lhs = this.Compile();
				return (lhs == ((int)obj));
			}
			else if (obj is ExpressionProxy)
			{
				return (this == (ExpressionProxy)obj);
			}
			else
			{
				return base.Equals(obj);
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
