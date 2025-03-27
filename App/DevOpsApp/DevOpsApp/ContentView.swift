//
//  ContentView.swift
//  DevOpsApp
//
//  Created by Jesus Juarez on 26/03/25.
//

import SwiftUI

struct ContentView: View {
    var body: some View {
        TabView {
            ProjectMainView()
                .tabItem {
                    Label("Projects", systemImage: "folder")
                }

            Text("Bienvenido a la app")
                .tabItem {
                    Label("Home", systemImage: "house")
                }
        }
    }
}
