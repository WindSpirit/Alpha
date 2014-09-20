/*
 * Android seems to have an issue ellipsizing when one allows for more than a single line of text.
 * When there is only a single line of text to display, the following will xml will work:
 * 
 *		android:ellipsize="end"
 * 		android:scrollHorizontally="false"
 * 		android:maxLines="1"
 * 		android:singleLine="true"
 * 
 * However, the following TextView subclass will be needed when more than a
 * single line of text needs to be displayed...
 * 
 * See also: http://stackoverflow.com/questions/2160619/android-ellipsize-multiline-textview
 * 
 */


using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Widget;

using Java.Lang;

using String = System.String;


namespace Alpha.Droid.Controls
{
	public class EllipsizingTextView : TextView
	{
		private static readonly string ELLIPSIS = "...";

		public EllipsizingTextView(Context context) : base(context)
		{
		}

		public EllipsizingTextView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
		}

		protected EllipsizingTextView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		public EllipsizingTextView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
		{
		}


		public interface EllipsizeListener
		{
			void ellipsizeStateChanged(bool ellipsized);
		}

		private readonly List<EllipsizeListener> ellipsizeListeners = new List<EllipsizeListener>();
		private bool isEllipsized;
		private bool isStale;
	    private bool programmaticChange;
		private String fullText;
		private int maxLines = -1;
		private float lineSpacingMultiplier = 1.0f;
		private float lineAdditionalVerticalPadding = 0.0f;

	    public void addEllipsizeListener(EllipsizeListener listener) 
		{
			if (listener == null) {
				throw new NullPointerException();
			}
			ellipsizeListeners.Add(listener);
		}

		public void removeEllipsizeListener(EllipsizeListener listener) {
			ellipsizeListeners.Remove(listener);
		}

		public override void SetMaxLines(int maxlines)
		{
			base.SetMaxLines(maxlines);
			this.maxLines = maxlines;
		    isStale = true;
		}

	    public int getMaxLines() {
		    return maxLines;
		}

		public override void SetLineSpacing(float add, float mult) {
			this.lineAdditionalVerticalPadding = add;
			this.lineSpacingMultiplier = mult;
			base.SetLineSpacing(add, mult);
		}


		protected override void OnTextChanged ( ICharSequence text, int start, int lengthBefore, int lengthAfter ) {
			base.OnTextChanged ( text, start, lengthBefore, lengthAfter );
			if ( !programmaticChange ) {
				fullText = text.ToString ( );
				isStale = true;
			}
		}

		protected override void OnDraw(Canvas canvas)
		{
			if (isStale) {
				base.Ellipsize = null;
				resetText();
			}
		   base.OnDraw(canvas);
		}

		private void resetText() {
			int maxLines = getMaxLines();
			String workingText = fullText;
			bool ellipsized = false;
			if (maxLines != -1) {
				Layout layout = createWorkingLayout(workingText);
				if (layout.LineCount > maxLines) {
					workingText = fullText.Substring(0, layout.GetLineEnd(maxLines - 1)).Trim();
					while (createWorkingLayout(workingText + ELLIPSIS).LineCount > maxLines) {
						int lastSpace = workingText.LastIndexOf(' ');
						if (lastSpace == -1) {
							break;
						}
						workingText = workingText.Substring(0, lastSpace);
					}
					workingText = workingText + ELLIPSIS;
					ellipsized = true;
				}
			}
			if (!workingText.Equals(Text)) {
				programmaticChange = true;
				try {
					Text = workingText;
				} finally {
					programmaticChange = false;
				}
			}
			isStale = false;
			if (ellipsized != isEllipsized) {
				isEllipsized = ellipsized;
				foreach (var listener in ellipsizeListeners) {
					listener.ellipsizeStateChanged(ellipsized);
				}
			}
		}

		private Layout createWorkingLayout(String workingText) {
			return new StaticLayout(workingText, Paint, Width - PaddingLeft - PaddingRight,
					Layout.Alignment.AlignNormal, lineSpacingMultiplier, lineAdditionalVerticalPadding, false);
		}

		public void setEllipsize(TextUtils.TruncateAt where) {
			// Ellipsize settings are not respected
		}


	}
}