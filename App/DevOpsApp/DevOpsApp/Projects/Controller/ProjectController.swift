//
//  ProjectViewModel.swift
//  DevOpsApp
//
//  Created by Jesus Juarez on 27/03/25.
//

import Foundation

class ProjectController: ObservableObject {
    @Published var projects: [ProjectDTO] = []

    func fetchProjects() {
        guard let url = URL(string: "http://192.168.1.36:5001/Projects") else { return }

        URLSession.shared.dataTask(with: url) { data, response, error in
            if let data = data {
                do {
                    let decodedProjects = try JSONDecoder().decode([ProjectDTO].self, from: data)
                    DispatchQueue.main.async {
                        self.projects = decodedProjects
                    }
                } catch {
                    print("Error decoding JSON: \(error)")
                }
            }
        }.resume()
    }

    func insertProject(name: String, description: String?, repository: String?, completion: @escaping (Bool) -> Void) {
        guard let url = URL(string: "http://192.168.1.36:5001/Projects") else { return }

        var request = URLRequest(url: url)
        request.httpMethod = "POST"
        request.setValue("application/json", forHTTPHeaderField: "Content-Type")

        let newProject = ProjectDTOInput(name: name, description: description, repository: repository)

        do {
            request.httpBody = try JSONEncoder().encode(newProject)
        } catch {
            print("Error al codificar el JSON: \(error)")
            completion(false)
            return
        }

        URLSession.shared.dataTask(with: request) { data, response, error in
            if let httpResponse = response as? HTTPURLResponse, httpResponse.statusCode == 200 {
                DispatchQueue.main.async {
                    self.fetchProjects()  // 🔥 Recargar la lista de proyectos
                    completion(true)
                }
            } else {
                DispatchQueue.main.async {
                    completion(false)
                }
            }
        }.resume()
    }
}
