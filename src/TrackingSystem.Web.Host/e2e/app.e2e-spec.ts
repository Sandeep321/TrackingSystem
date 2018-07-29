import { TrackingSystemTemplatePage } from './app.po';

describe('TrackingSystem App', function() {
  let page: TrackingSystemTemplatePage;

  beforeEach(() => {
    page = new TrackingSystemTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
