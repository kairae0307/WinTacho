using System;
using System.Collections;
using System.Collections.Generic;

// The ColHeader class is a ColumnHeader object with an
// added property for determining an ascending or descending sort.
// True specifies an ascending order, false specifies a descending order.
public class ColHeader : ColumnHeader
{
    public bool ascending;
    public ColHeader(string text, int width, HorizontalAlignment align, bool asc)
    {
        this.Text = text;
        this.Width = width;
        this.TextAlign = align;
        this.ascending = asc;
    }
}
