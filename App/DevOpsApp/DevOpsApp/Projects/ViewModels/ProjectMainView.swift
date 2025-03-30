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
        @State private var selectedProject: ProjectDTO?

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
                            Image(systemName: "chevron.forward") // 🔥 Indicador de swipe
                                .foregroundColor(.gray)
                        }
                        .contentShape(Rectangle()) // Asegura que toda la fila sea táctil
                        .swipeActions(edge: .trailing) {
                            // Botón de Editar
                            Button {
                                selectedProject = project
                            } label: {
                                Label("Edit", systemImage: "pencil")
                            }
                            .tint(.blue)

                            // Botón de Archivar
                            Button {
                                projectController.archiveProject(project.id) { _ in }
                            } label: {
                                Label("Archive", systemImage: "archivebox")
                            }
                            .tint(.orange)

                            // Botón de Eliminar (Desactivar)
                            Button(role: .destructive) {
                                projectController.deleteProject(project.id) { _ in }
                            } label: {
                                Label("Delete", systemImage: "trash")
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
                .sheet(item: $selectedProject) { project in
                    ProjectEditView(project: project)
                        .environmentObject(projectController)
                }
            }
            .onAppear {
                projectController.fetchProjects()
            }
        }
}
