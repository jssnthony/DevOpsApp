//
//  Project.swift
//  DevOpsApp
//
//  Created by Jesus Juarez on 27/03/25.
//

import Foundation

struct ProjectDTO: Codable, Identifiable {
    let id: String
    let title: String
    let description: String
    let repository: String
}
