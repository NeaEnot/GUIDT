using Core.Attributes;
using Core.Models.View;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Test.CoreTest
{
    public class AttributesTest
    {
        [Fact]
        public void TestColumnAttribute()
        {
            ColumnAttribute attribute = new ColumnAttribute("Test", true);

            Assert.Equal("Test", attribute.Title);
            Assert.True(attribute.Visible);
        }

        [Fact]
        public void TestProductViewColumnAttributes()
        {
            Type type = typeof(ProductView);
            ColumnAttribute attrId = null;
            ColumnAttribute attrName = null;
            ColumnAttribute attrPrice = null;

            foreach (PropertyInfo prop in type.GetProperties().Where(rec => rec.GetCustomAttributes<ColumnAttribute>().Count() > 0))
            {
                switch (prop.Name)
                {
                    case "Id":
                        attrId = prop.GetCustomAttribute<ColumnAttribute>();
                        break;
                    case "Name":
                        attrName = prop.GetCustomAttribute<ColumnAttribute>();
                        break;
                    case "Price":
                        attrPrice = prop.GetCustomAttribute<ColumnAttribute>();
                        break;
                }
            }

            Assert.Equal("Номер", attrId.Title);
            Assert.True(attrId.Visible);
            Assert.Equal("Название", attrName.Title);
            Assert.True(attrName.Visible);
            Assert.Equal("Цена", attrPrice.Title);
            Assert.True(attrPrice.Visible);
        }

        [Fact]
        public void TestOrderViewColumnAttributes()
        {
            Type type = typeof(OrderView);
            ColumnAttribute attrId = null;
            ColumnAttribute attrSum = null;

            foreach (PropertyInfo prop in type.GetProperties().Where(rec => rec.GetCustomAttributes<ColumnAttribute>().Count() > 0))
            {
                switch (prop.Name)
                {
                    case "Id":
                        attrId = prop.GetCustomAttribute<ColumnAttribute>();
                        break;
                    case "Sum":
                        attrSum = prop.GetCustomAttribute<ColumnAttribute>();
                        break;
                }
            }

            Assert.Equal("Номер", attrId.Title);
            Assert.True(attrId.Visible);
            Assert.Equal("Сумма", attrSum.Title);
            Assert.True(attrSum.Visible);
        }
    }
}
