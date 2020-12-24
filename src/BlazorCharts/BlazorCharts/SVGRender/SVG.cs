using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BlazorCharts.SVGRender
{
    public class SVG : IEnumerable<string>
    {

        readonly List<string> internalList = new();
        readonly List<SVG> m_innerCollection = new();
        internal SvgType Type { get; private set; }
        internal string TypeName =>
            Type switch
            {
                SvgType.Group => "g",
                SvgType.Circle => "circle",
                SvgType.Path => "path",
                SvgType.Rectangle => "rect",
                SvgType.Text => "text",
                _ => "svg"
            };

        internal SVG() : this(null) { }
        internal SVG(SvgType? type)
        {
            Type = type ?? SvgType.Svg;
        }

        public IEnumerator<string> GetEnumerator() => internalList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => internalList.GetEnumerator();
        
        //public IEnumerator<SVG> GetItemsEnumerator() => m_innerCollection.GetEnumerator();
        //IEnumerator IEnumerable.GetEnumerator() => m_innerCollection.GetEnumerator();

        public List<string> GetAttributes() => internalList;

        public void Add(string name, string value) => internalList.Add($@"{name}={value}");

        public List<SVG> GetChildren() => m_innerCollection;


        public void AddItems(params SVG[] items)
        {
            foreach (var item in items)
                m_innerCollection.Add(item);
        }

        //public void Draw()
        //{
        //    //if here it will end up depnednecy on buildrendertree
        //}
    }
}
