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

    @State private var title: String = ""
    @State private var description: String = ""
    @State private var repository: String = ""

    var body: some View {
        NavigationView {
            Form {
                Section(header: Text("Project Details")) {
                    TextField("Title", text: $title)
                    TextField("Description", text: $description)
                    TextField("Repository", text: $repository)
                }

                Button("Save Project") {
                    projectController.insertProject(title: title, description: description, repository: repository) { success in
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
