package com.project.service;

import com.project.domain.Departman;

public interface DepartmanService {

	Departman save(Departman u);
	boolean delete(Departman u);
	Departman change(Departman u);
}
