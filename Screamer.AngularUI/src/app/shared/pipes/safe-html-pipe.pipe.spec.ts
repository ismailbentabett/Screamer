import { SafeHtmlPipePipe } from './safe-html-pipe.pipe';

describe('SafeHtmlPipePipe', () => {
  it('create an instance', () => {
    const pipe = new SafeHtmlPipePipe();
    expect(pipe).toBeTruthy();
  });
});
