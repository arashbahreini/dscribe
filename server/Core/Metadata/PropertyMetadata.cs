using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Brainvest.Dscribe.Abstractions;
using Brainvest.Dscribe.Abstractions.Metadata;
using Brainvest.Dscribe.Helpers;
using Brainvest.Dscribe.MetadataDbAccess.Entities;

namespace Brainvest.Dscribe.Metadata
{
	public class PropertyMetadata : FacetOwner, IPropertyMetadata
	{
		public PropertyGeneralUsageCategoryStruct GeneralBahvior { get; private set; }
		public string Name { get; set; }
		public string Title { get; set; }

		public EntityMetadata Owner { get; set; }
		public DataTypes DataType { get; set; }
		public bool IsNullable { get; set; }
		public bool IsExpression { get; set; }
		public string EntityTypeName { get; set; }

		public IPropertyMetadata ForeignKey { get; set; }
		public IPropertyMetadata InverseProperty { get; set; }

		#region Facets
		public static PropertyFacet<string> FriendlyNameFacet { get; private set; }
		public static PropertyFacet<bool> IsRequiredFacet { get; private set; }
		public static PropertyFacet<bool> ReadOnlyInEditFacet { get; private set; }
		public static Dictionary<int, Facet> _facets { get; private set; } = new Dictionary<int, Facet>();

		private string _expressionDefinitionIdentifier;
		private LambdaExpression _definitionExpression;
		public LambdaExpression GetDefiningExpression(IBusinessReflector reflector)
		{
			if (_definitionExpression != null || _expressionDefinitionIdentifier == null)
			{
				return _definitionExpression;
			}
			_definitionExpression = _cache.GetExpression(_expressionDefinitionIdentifier, reflector);
			return _definitionExpression;
		}

		public static void DefineFacets(IEnumerable<PropertyFacetDefinition> propertyFacetDefinitions)
		{
			FriendlyNameFacet = new PropertyFacet<string>(nameof(FriendlyNameFacet), null, source => source.Name.SmartSeparate());
			IsRequiredFacet = new PropertyFacet<bool>(nameof(IsRequiredFacet), false, source => !source.IsNullable);
			ReadOnlyInEditFacet = new PropertyFacet<bool>(nameof(ReadOnlyInEditFacet), false, null);
			ReflectionHelper.FillFacetsDictionary<PropertyMetadata>(_facets, propertyFacetDefinitions, typeof(PropertyFacet<>));
		}

		private IDataTypeInfo _dataTypeInfo;
		public IDataTypeInfo GetDataType()
		{
			return _dataTypeInfo;
		}

		public bool IsReadOnlyInEdit()
		{
			return GetFacetValue<bool>(ReadOnlyInEditFacet);
		}
		public bool IsRequired()
		{
			return GetFacetValue<bool>(IsRequiredFacet);
		}
		#endregion
		private IMetadataCache _cache;
		public PropertyMetadata(IMetadataCache cache, string name, EntityMetadata owner, PropertyGeneralUsageCategoryStruct generalBehavior
			, DataType dataType, bool isNullable, bool isExpression, string title, string expressionDefinitionIdentifier)
		{
			_cache = cache;
			Name = name;
			Title = title;
			GeneralBahvior = generalBehavior;
			_dataTypeInfo = dataType;
			DataType = (DataTypes)dataType.Id;
			IsNullable = isNullable;
			IsExpression = isExpression;
			_expressionDefinitionIdentifier = expressionDefinitionIdentifier;
			owner.AddProperty(this);
			Owner = owner;
		}
	}
}