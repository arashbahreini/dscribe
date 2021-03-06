using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Brainvest.Dscribe.Abstractions.Metadata
{
	public interface IPropertyMetadata
	{
		string Name { get; }
		bool IsExpression { get; }
		string EntityTypeName { get; }
		DataTypes DataType { get; }
		bool IsNullable { get; }
		string Title { get; }

		IPropertyMetadata InverseProperty { get; }
		IPropertyMetadata ForeignKey { get; }

		LambdaExpression GetDefiningExpression(IBusinessReflector reflector);

		IDataTypeInfo GetDataType();
		bool IsReadOnlyInEdit();
		bool IsRequired();
	}
}