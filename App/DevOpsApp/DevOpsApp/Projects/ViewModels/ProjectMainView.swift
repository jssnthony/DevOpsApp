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
    @State private var selectedProject: ProjectDTO? // 🔥 Estado para la edición

    var body: some View {
        NavigationView {
            List {
                ForEach(projectController.projects) { project in
                    HStack {
                        VStack(alignment: .leading) {
                            Text(project.title).font(.headline)
                            Text(project.description).font(.subheadline)
                        }
                        Spacer()
                        Button(action: { selectedProject = project }) { // 🔥 Botón de edición
                            Image(systemName: "pencil.circle")
                                .foregroundColor(.blue)
                        }
                    }
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
                    .environmentObject(projectController)
            }
            .sheet(item: $selectedProject) { project in // 🔥 Muestra la vista de edición
                ProjectEditView(project: project)
                    .environmentObject(projectController)
            }
        }
        .onAppear {
            projectController.fetchProjects()
        }
    }
}
