//
//  ProjectViewModel.swift
//  DevOpsApp
//
//  Created by Jesus Juarez on 27/03/25.
//

import Foundation

class ProjectViewModel: ObservableObject {
    @Published var projects: [Project] = []

    func fetchProjects() {
        guard let url = URL(string: "http://192.168.1.36:5001/Project") else { return }

        URLSession.shared.dataTask(with: url) { data, response, error in
            if let data = data {
                do {
                    let decodedProjects = try JSONDecoder().decode([Project].self, from: data)
                    DispatchQueue.main.async {
                        self.projects = decodedProjects
                    }
                } catch {
                    print("Error decoding JSON: \(error)")
                }
            }
        }.resume()
    }
}
