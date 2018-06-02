package com.project.service;

import java.util.ArrayList;

import com.project.domain.Ucionica;

public interface ClassroomService {
	Ucionica save(Ucionica u);
	boolean delete(Ucionica u);
	Ucionica change(Ucionica u);
	ArrayList<Ucionica> get();
}
