//
//  ProjectMainView.swift
//  DevOpsApp
//
//  Created by Jesus Juarez on 27/03/25.
//


import SwiftUI

struct ProjectMainView: View {
    @EnvironmentObject var projectController: ProjectController
    @State private var showInsertView = false

    var body: some View {
        NavigationView {
            List(projectController.projects) { project in
                VStack(alignment: .leading) {
                    Text(project.name).font(.headline)
                    Text(project.description).font(.subheadline)
                }
            }
            .navigationTitle("Projects")
            .toolbar {
                Button(action: { showInsertView = true }) {
                    Label("Add", systemImage: "plus")
                }
            }
            .sheet(isPresented: $showInsertView) {
                ProjectInsertView()
                    .environmentObject(projectController) // 🔥 Se pasa la instancia
            }
        }
        .onAppear {
            projectController.fetchProjects()
        }
    }
}
