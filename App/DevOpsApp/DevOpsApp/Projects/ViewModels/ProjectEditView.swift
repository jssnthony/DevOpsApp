//
//  ProjectEditView.swift
//  DevOpsApp
//
//  Created by Jesus Juarez on 29/03/25.
//

import SwiftUI

struct ProjectEditView: View {
    @Environment(\.presentationMode) var presentationMode
    @EnvironmentObject var projectController: ProjectController // 🔥 ViewModel global

    var project: ProjectDTO // Recibe el proyecto a editar

    @State private var title: String
    @State private var description: String
    @State private var repository: String

    init(project: ProjectDTO) {
        self.project = project
        _title = State(initialValue: project.title)
        _description = State(initialValue: project.description)
        _repository = State(initialValue: project.repository)
    }

    var body: some View {
        NavigationView {
            Form {
                Section(header: Text("Edit Project")) {
                    TextField("Title", text: $title)
                    TextField("Description", text: $description)
                    TextField("Repository", text: $repository)
                }

                Button("Update Project") {
                    updateProject()
                }
                .buttonStyle(.borderedProminent)
            }
            .navigationTitle("Edit Project")
        }
    }

    func updateProject() {
        let updatedProject = ProjectDTO(
            id: project.id,
            title: title,
            description: description,
            repository: repository
        )

        projectController.updateProject(updatedProject) { success in
            if success {
                presentationMode.wrappedValue.dismiss() // 🔥 Cierra la vista
            }
        }
    }
}

