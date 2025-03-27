//
//  ProjectsView.swift
//  DevOpsApp
//
//  Created by Jesus Juarez on 27/03/25.
//

import SwiftUI

struct ProjectsView: View {
    @StateObject private var viewModel = ProjectViewModel()

    var body: some View {
        NavigationView {
            List(viewModel.projects) { project in
                VStack(alignment: .leading) {
                    Text(project.name)
                        .font(.headline)
                    Text(project.description)
                        .font(.subheadline)
                        .foregroundColor(.gray)
                    Text("Repo: \(project.repository)")
                        .font(.footnote)
                        .foregroundColor(.blue)
                }
                .padding(.vertical, 5)
            }
            .navigationTitle("Projects")
            .onAppear {
                viewModel.fetchProjects()
            }
        }
    }
}

struct ProjectsView_Previews: PreviewProvider {
    static var previews: some View {
        ProjectsView()
    }
}
