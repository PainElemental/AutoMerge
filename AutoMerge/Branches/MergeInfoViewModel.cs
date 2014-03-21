﻿using System;
using System.Collections.Generic;
using AutoMerge.Events;
using Microsoft.Practices.Prism.Events;

namespace AutoMerge
{
	public class MergeInfoViewModel
	{
		private readonly IEventAggregator _eventAggregator;
		private bool _checked;

		public MergeInfoViewModel(IEventAggregator eventAggregator)
		{
			_eventAggregator = eventAggregator;
		}

		public bool Checked
		{
			get
			{
				return _checked;
			}
			set
			{
				_checked = value;
				_eventAggregator.GetEvent<BranchSelectedChangedEvent>().Publish(this);
			}
		}

		public string SourceBranch { get; set; }

		public string TargetBranch { get; set; }

		public string Comment { get; set; }

		public string DisplayBranchName
		{
			get
			{
				return BranchHelper.GetShortBranchName(TargetBranch);
			}
		}

		public List<FileMergeInfo> FileMergeInfos { get; set; }

		public BranchValidationResult ValidationResult { get; set; }

		public string ValidationMessage { get; set; }

		public bool IsSourceBranch
		{
			get
			{
				return string.Equals(SourceBranch, TargetBranch, StringComparison.OrdinalIgnoreCase);
			}
		}
	}
}