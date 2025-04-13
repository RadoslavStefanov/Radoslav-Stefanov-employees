import { ProjectsInfo } from "./ProjectsInfo.model";

export class PairResults {
    empId1: Number;
    empId2: Number;
    totalDaysWorked: Number;
    projects: [ProjectsInfo];

    constructor(empId1: Number, empId2: Number, totalDaysWorked: Number, projects: [ProjectsInfo]) {
        this.empId1 = empId1;
        this.empId2 = empId2;
        this.totalDaysWorked = totalDaysWorked;
        this.projects = projects;
    }
    
}

