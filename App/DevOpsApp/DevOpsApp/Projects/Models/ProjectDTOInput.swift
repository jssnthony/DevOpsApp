//
//  ProjectInput.swift
//  DevOpsApp
//
//  Created by Jesus Juarez on 27/03/25.
//

import Foundation

struct ProjectDTOInput: Codable {
    let name: String
    let description: String?
    let repository: String?
}
