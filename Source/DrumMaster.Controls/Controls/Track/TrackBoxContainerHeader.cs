﻿using Restless.App.DrumMaster.Controls.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;

namespace Restless.App.DrumMaster.Controls
{
    /// <summary>
    /// Represents a container for a series of <see cref="TrackBox"/> items
    /// that represent the header for a series of tracks.
    /// </summary>
    //[TemplatePart(Name = PartHostGrid, Type = typeof(Grid))]
    public class TrackBoxContainerHeader : TrackBoxContainerBase
    {
        #region Private
        //private const string PartHostGrid = "PART_HOST_GRID";
        //private Grid hostGrid;
        // private readonly CompositeTrack compositeTrackOwner;
        private readonly TrackContainer owner;
        //private TrackController controller;
        private XElement holdElement;
        #endregion

        /************************************************************************/

        #region Public properties (Type / Steps)
        #endregion

        /************************************************************************/

        #region Public properties (Brushes)
        #endregion

        /************************************************************************/

        #region Routed Events
        #endregion

        /************************************************************************/

        #region Internal properties
        ///// <summary>
        ///// Gets a collection of track boxes
        ///// </summary>
        //internal TrackBoxCollection Boxes
        //{
        //    get;
        //}
        #endregion

        /************************************************************************/

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackBoxContainerHeader"/> class.
        /// </summary>
        internal TrackBoxContainerHeader(TrackContainer owner)
        {
            this.owner = owner ?? throw new ArgumentNullException(nameof(owner));
            BoxType = TrackBoxType.Header;
        }

        static TrackBoxContainerHeader()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(TrackBoxContainerStep), new FrameworkPropertyMetadata(typeof(TrackBoxContainerStep)));
        }
        #endregion

        /************************************************************************/

        #region Public methods
        ///// <summary>
        ///// Called when the template is applied.
        ///// </summary>
        //public override void OnApplyTemplate()
        //{
        //    base.OnApplyTemplate();
        //    hostGrid = GetTemplateChild(PartHostGrid) as Grid;
        //    OnTotalStepsChanged();
        //    if (holdElement != null)
        //    {
        //        RestoreFromXElement(holdElement);
        //    }
        //}
        #endregion

        /************************************************************************/

        #region IXElement
        /// <summary>
        /// Gets the XElement for this object.
        /// </summary>
        /// <returns>The XElement that describes the state of this object.</returns>
        public override XElement GetXElement()
        {
            var element = new XElement(nameof(TrackBoxContainerHeader));
            foreach (var box in Boxes)
            {
                element.Add(box.GetXElement());
            }
            return element;
        }

        /// <summary>
        /// Restores the object from the specified XElement
        /// </summary>
        /// <param name="element">The element</param>
        public override void RestoreFromXElement(XElement element)
        {
            holdElement = element;
            if (IsTemplateApplied)
            {
                IEnumerable<XElement> childList = from el in element.Elements() select el;
                int boxIndex = 0;
                foreach (XElement e in childList)
                {
                    if (e.Name == nameof(TrackBox))
                    {
                        if (boxIndex < Boxes.Count)
                        {
                            Boxes[boxIndex].RestoreFromXElement(e);
                        }
                        boxIndex++;
                    }
                }
                ResetIsChanged();
            }
        }
        #endregion

        /************************************************************************/

        #region Protected methods
        /// <summary>
        /// Called when the <see cref="TrackStepControl.TotalSteps"/> property changes.
        /// Places the beat markers in the header.
        /// </summary>
        protected override void OnTotalStepsChanged()
        {
            // The base method adjusts the visual grid
            base.OnTotalStepsChanged();
            // Update the beat labels
            int beat = 1;
            for (int k = 0; k < Boxes.Count; k++)
            {
                Boxes[k].Text = (k % StepsPerBeat == 0) ? $"{beat++}" : string.Empty;
            }

















        }
        ///// <summary>
        ///// Called when the box size is changed
        ///// </summary>
        //protected override void OnBoxSizeChanged()
        //{
        //    base.OnBoxSizeChanged();
        //    foreach (var box in Boxes)
        //    {
        //        box.Width = box.Height = BoxSize;
        //    }
        //}

        ///// <summary>
        ///// Deselects all boxes.
        ///// </summary>
        //public void DeselectAllBoxes()
        //{
        //    Boxes.SetAllTo(StepPlayFrequency.None);
        //}
        #endregion

        /************************************************************************/

        #region Internal methods
        ///// <summary>
        ///// From this assembly, sets the track controller
        ///// </summary>
        ///// <param name="controller">The controller.</param>
        //internal void SetController(TrackController controller)
        //{
        //    this.controller = controller ?? throw new ArgumentNullException(nameof(controller));
        //    controller.SizeChanged += ControllerSizeChanged;
        //}

        ///// <summary>
        ///// From this assembly, gets a value that indicates if the specified
        ///// pass and step can play.
        ///// </summary>
        ///// <param name="pass">The pass</param>
        ///// <param name="step">The step</param>
        ///// <returns>true if pass/step can play; otherwise, false.</returns>
        //internal bool CanPlay(int pass, int step)
        //{
        //    if (step < Boxes.Count)
        //    {
        //        return Boxes[step].CanPlay(pass);
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// From this assembly, resets the volume bias on each <see cref="TrackBox"/> in the container.
        ///// </summary>
        //internal void ResetVolumeBias()
        //{
        //    foreach (TrackBox box in Boxes)
        //    {
        //        box.VolumeBias = TrackVals.VolumeBias.Default;
        //    }
        //}

        ///// <summary>
        ///// From this assembly, removes any human volume bias from each <see cref="TrackBox"/> in the container.
        ///// </summary>
        //internal void RemoveHumanVolumeBias()
        //{
        //    foreach (TrackBox box in Boxes)
        //    {
        //        box.RemoveHumanVolumeBias();
        //    }
        //}
        #endregion

        /************************************************************************/

        #region Private methods (Instance)


        private void ControllerSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.HeightChanged)
            {
                Height = e.NewSize.Height;
            }
        }
        #endregion
    }
}
