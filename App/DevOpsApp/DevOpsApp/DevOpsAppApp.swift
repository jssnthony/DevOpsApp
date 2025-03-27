//
//  DevOpsAppApp.swift
//  DevOpsApp
//
//  Created by Jesus Juarez on 26/03/25.
//

import SwiftUI

@main
struct DevOpsAppApp: App {
    @StateObject private var projectController = ProjectController() // 🔥 Instancia global del ViewModel

    var body: some Scene {
        WindowGroup {
            ContentView()
                .environmentObject(projectController) // 🔥 Se pasa como EnvironmentObject a toda la app
        }
    }
}
