using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
	public class ContextMenuStripEx : ContextMenuStrip
	{
		public ContextMenuStripEx() : base() {}

		public ContextMenuStripEx(ContextMenuStrip value)
		{
			this.AccessibleDefaultActionDescription = value.AccessibleDefaultActionDescription;
			this.AccessibleDescription = value.AccessibleDescription;
			this.AccessibleName = value.AccessibleName;
			this.AccessibleRole = value.AccessibleRole;
			this.AllowDrop = value.AllowDrop;
			this.AllowMerge = value.AllowMerge;
			this.AllowTransparency = value.AllowTransparency;
			this.AutoClose = value.AutoClose;
			this.AutoScrollOffset = value.AutoScrollOffset;
			this.AutoSize = value.AutoSize;
			this.BackColor = value.BackColor;
			this.BackgroundImage = value.BackgroundImage;
			this.BackgroundImageLayout = value.BackgroundImageLayout;
			this.BindingContext = value.BindingContext;
			this.Bounds = value.Bounds;
			this.Capture = value.Capture;
			this.CausesValidation = value.CausesValidation;
			this.ClientSize = value.ClientSize;
			this.Cursor = value.Cursor;
			this.DefaultDropDownDirection = value.DefaultDropDownDirection;
			this.Dock = value.Dock;
			this.DoubleBuffered = typeof(ContextMenuStrip).GetProperty(nameof(this.DoubleBuffered), System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetProperty)?.GetValue(value) is bool b ? b : this.DoubleBuffered;
			this.DropShadowEnabled = value.DropShadowEnabled;
			this.Enabled = value.Enabled;
			this.ForeColor = value.ForeColor;
			this.Height = value.Height;
			this.ImageList = value.ImageList;
			this.ImageScalingSize = value.ImageScalingSize;
			this.ImeMode = value.ImeMode;
			this.IsAccessible = value.IsAccessible;
			this.Items.AddRange(value.Items);
			this.LayoutSettings = value.LayoutSettings;
			this.LayoutStyle = value.LayoutStyle;
			this.Left = value.Left;
			this.Margin = value.Margin;
			this.MaximumSize = value.MaximumSize;
			this.MinimumSize = value.MinimumSize;
			this.Name = value.Name;
			this.Opacity = value.Opacity;
			this.OwnerItem = value.OwnerItem;
			this.Padding = value.Padding;
			this.Region = value.Region;
			this.Renderer = value.Renderer;
			this.RenderMode = value.RenderMode;
			this.RightToLeft = value.RightToLeft;
			this.ShowCheckMargin = value.ShowCheckMargin;
			this.ShowImageMargin = value.ShowImageMargin;
			this.ShowItemToolTips = value.ShowItemToolTips;
			this.Site = value.Site;
			this.TabStop = value.TabStop;
			this.Tag = value.Tag;
			this.Text = value.Text;
			this.TextDirection = value.TextDirection;
			this.Top = value.Top;
			this.TopLevel = value.TopLevel;
			this.UseWaitCursor = value.UseWaitCursor;
			this.Visible = value.Visible;
			this.Width = value.Width;
		}

		public Control SourceControlEx { get; private set; } = null;

		/// <summary>
		/// Tagプロパティに自身を呼び出したコントロールへの参照を保存
		/// </summary>
		protected override void OnOpening(CancelEventArgs e) => SourceControlEx = SourceControl;
	}
}
