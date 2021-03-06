﻿using ColossalFramework;
using CSUtil.Commons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TrafficManager.Custom.AI;
using TrafficManager.State;
using TrafficManager.Traffic;
using TrafficManager.Traffic.Data;
using TrafficManager.Util;
using UnityEngine;

namespace TrafficManager.Manager.Impl {
	public class ExtBuildingManager : AbstractCustomManager, IExtBuildingManager {
		public static ExtBuildingManager Instance { get; private set; } = null;

		static ExtBuildingManager() {
			Instance = new ExtBuildingManager();
		}
		
		/// <summary>
		/// All additional data for buildings
		/// </summary>
		public ExtBuilding[] ExtBuildings = null;

		private ExtBuildingManager() {
			ExtBuildings = new ExtBuilding[BuildingManager.MAX_BUILDING_COUNT];
			for (uint i = 0; i < BuildingManager.MAX_BUILDING_COUNT; ++i) {
				ExtBuildings[i] = new ExtBuilding((ushort)i);
			}
		}

		protected override void InternalPrintDebugInfo() {
			base.InternalPrintDebugInfo();
			Log._Debug($"Extended building data:");
			for (int i = 0; i < ExtBuildings.Length; ++i) {
				if (! ExtBuildings[i].IsValid()) {
					continue;
				}
				Log._Debug($"Building {i}: {ExtBuildings[i]}");
			}
		}
		
		public override void OnLevelUnloading() {
			base.OnLevelUnloading();
			for (int i = 0; i < ExtBuildings.Length; ++i)
				ExtBuildings[i].Reset();
		}
	}
}
