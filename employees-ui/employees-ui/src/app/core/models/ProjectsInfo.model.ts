export class ProjectsInfo {
    projectId: number;
    commonDays: number;

    constructor(projectId: number, commonDays: number) {
        this.projectId = projectId;
        this.commonDays = commonDays;
    }
}