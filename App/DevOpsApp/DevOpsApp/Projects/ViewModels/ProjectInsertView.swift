//
//  InsertProjectView.swift
//  DevOpsApp
//
//  Created by Jesus Juarez on 27/03/25.
//

import SwiftUI

struct ProjectInsertView: View {
    @Environment(\.presentationMode) var presentationMode
    @EnvironmentObject var projectController: ProjectController

    @State private var name: String = ""
    @State private var description: String = ""
    @State private var repository: String = ""

    var body: some View {
        NavigationView {
            Form {
                Section(header: Text("Project Details")) {
                    TextField("Name", text: $name)
                    TextField("Description", text: $description)
                    TextField("Repository", text: $repository)
                }

                Button("Save Project") {
                    projectController.insertProject(name: name, description: description, repository: repository) { success in
                        if success {
                            presentationMode.wrappedValue.dismiss()
                        }
                    }
                }
                .buttonStyle(.borderedProminent)
            }
            .navigationTitle("New Project")
        }
    }
}
